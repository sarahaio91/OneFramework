import { Component, Input } from '@angular/core';
import { Hero } from '../models/hero';

@Component({
  selector: 'hero-detail',
  templateUrl: '../../views/hero-detail.component.html'
})

export class HeroDetailComponent {
    @Input() hero: Hero;
}
