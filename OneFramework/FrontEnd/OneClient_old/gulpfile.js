const del = require('del');
const gulp = require('gulp');
const runSequence = require('run-sequence');
const plugin = require('gulp-load-plugins')();
const tsc = require('gulp-typescript');
const sysBuilder = require('systemjs-builder');

const tscConfig = require('./tsconfig.json');

// Clean library directory
gulp.task('clean:lib', function () {
  return del('public/lib/**/*');
});

// Copy dependencies
gulp.task('copy:libs', function() {
  gulp.src(['node_modules/rxjs/**/*'])
    .pipe(gulp.dest('public/lib/js/rxjs'));

  // concatenate non-angular2 libs, shims & systemjs-config
  gulp.src([
    'node_modules/jquery/dist/jquery.min.js',
    'node_modules/bootstrap/dist/js/bootstrap.min.js',
    'node_modules/es6-shim/es6-shim.min.js',
    'node_modules/es6-promise/dist/es6-promise.min.js',
    'node_modules/zone.js/dist/zone.js',
    'node_modules/reflect-metadata/Reflect.js',
    // 'node_modules/systemjs/dist/system-polyfills.js',
    'node_modules/systemjs/dist/system.src.js',
    'system.config.js',
  ])
    .pipe(plugin.concat('vendors.min.js'))
    .pipe(plugin.uglify())
    .pipe(gulp.dest('public/lib/js'));

  // copy source maps
  gulp.src([
    'node_modules/es6-shim/es6-shim.map',
    'node_modules/reflect-metadata/Reflect.js.map',
    'node_modules/systemjs/dist/system-polyfills.js.map'
  ]).pipe(gulp.dest('public/lib/js'));

  gulp.src([
    'node_modules/bootstrap/dist/css/bootstrap.*'
  ]).pipe(gulp.dest('public/lib/css'));

  return gulp.src(['node_modules/@angular/**/*'])
    .pipe(gulp.dest('public/lib/js/@angular'));
});

// Lint Typescript
gulp.task('lint:ts', function() {
  return gulp.src('src/**/*.ts')
    .pipe(plugin.tslint({
            formatter: "verbose"
        }))
    .pipe(plugin.tslint.report());
});

// Lint Sass
gulp.task('lint:sass', function() {
  return gulp.src('src/**/*.scss')
    .pipe(plugin.plumber({
      errorHandler: function (err) {
        console.error('>>> [sass-lint] Sass linting failed'.bold.green);
        this.emit('end');
      }}))
    .pipe(plugin.sassLint())
    .pipe(plugin.sassLint.format())
    .pipe(plugin.sassLint.failOnError());
});

gulp.task('clean:dist:js', function () {
  return del('public/dist/js/*');
});

// Compile TypeScript to JS
gulp.task('compile:ts', function () {
  return gulp
    .src(tscConfig.filesGlob)
    .pipe(plugin.plumber({
      errorHandler: function (err) {
        console.error('>>> [tsc] Typescript compilation failed'.bold.green);
        this.emit('end');
      }}))
    .pipe(plugin.sourcemaps.init())
    .pipe(tsc(tscConfig.compilerOptions))
    .pipe(plugin.sourcemaps.write('.'))
    .pipe(gulp.dest('public/dist/js'));
});

// Generate systemjs-based builds
gulp.task('bundle:js', function() {
  var builder = new sysBuilder('public', './system.config.js');
  return builder.buildStatic('app', 'public/dist/js/app/app.min.js')
    .then(function () {
      return del(['public/dist/js/app/**/*', '!public/dist/js/app/app.min.js']);
    })
    .catch(function(err) {
      console.error('>>> [systemjs-builder] Bundling failed'.bold.green, err);
    });
});

// Minify JS bundle
gulp.task('minify:js', function() {
  return gulp
    .src('public/dist/js/app.min.js')
    .pipe(plugin.uglify())
    .pipe(gulp.dest('public/dist/js'));
});

gulp.task('copy', function(callback) {
  runSequence('clean:lib', 'copy:libs', callback);
});

gulp.task('scripts', function(callback) {
  runSequence(['lint:ts', 'clean:dist:js'], 'compile:ts', 'bundle:js', 'minify:js', callback);
});

gulp.task('build', function(callback) {
  runSequence('copy', 'scripts', 'styles', callback);
});

gulp.task('default', function(callback) {
  runSequence('build', 'serve', callback);
});

