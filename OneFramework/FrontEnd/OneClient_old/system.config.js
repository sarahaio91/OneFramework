// map tells the System loader where to look for things
var map = {
  'app':                                'dist/js/app',
  'rxjs':                               'lib/js/rxjs',
  '@angular':                           'lib/js/@angular',
  // 'zone.js':                            'lib/js/zone.js/dist',
};

// packages tells the System loader how to load when no filename and/or no extension
var packages = {
  'app':                                { main: 'main', defaultExtension: 'js' },
  'rxjs':                               { defaultExtension: 'js' },
  // 'zone.js':                            { main: 'zone', defaultExtension: 'js' },
  '@angular/common':                    { main: 'common', defaultExtension: 'js' },
  '@angular/compiler':                  { main: 'compiler', defaultExtension: 'js' },
  '@angular/core':                      { main: 'core', defaultExtension: 'js' },
  '@angular/forms':                     { main: 'forms', defaultExtension: 'js' },
  '@angular/http':                      { main: 'http', defaultExtension: 'js' },
  '@angular/platform-browser':          { main: 'platform-browser', defaultExtension: 'js' },
  '@angular/platform-browser-dynamic':  { main: 'platform-browser-dynamic', defaultExtension: 'js' },
  '@angular/router':                    { main: 'router', defaultExtension: 'js' },
  '@angular/testing':                   { main: 'testing', defaultExtension: 'js' },
  '@angular/upgrade':                   { main: 'upgrade', defaultExtension: 'js' },
};

// var packageNames = [
//   '@angular/common',
//   '@angular/compiler',
//   '@angular/core',
//   '@angular/forms',
//   '@angular/http',
//   '@angular/platform-browser',
//   '@angular/platform-browser-dynamic',
//   '@angular/router',
//   '@angular/testing',
//   '@angular/upgrade',
// ];

// add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
// packageNames.forEach(function(pkgName) {
//   packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
// });

System.config({
  map: map,
  packages: packages
});
