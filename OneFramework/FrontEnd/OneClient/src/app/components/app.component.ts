import { Component } from '@angular/core';
import {Hero} from '../models/hero';

import '../../scss/styles.css';

const HEROES: Hero[] = [
  { id: 1, name: 'Kante' },
  { id: 2, name: 'Hazard' },
  { id: 3, name: 'Alonso' },
  { id: 4, name: 'Apilizcueta' },
  { id: 5, name: 'Luiz' },
  { id: 6, name: 'Costa' },
  { id: 7, name: 'Dybala' },
  { id: 8, name: 'Sturridge' },
  { id: 9, name: 'Messi' },
  { id: 10, name: 'Ronaldo' }
];

@Component({
  selector: 'my-app',
  templateUrl: '../../views/app.component.html',
  styleUrls: ['../../scss/components/app.component.css']
})
export class AppComponent {
    title = 'Tour of Heroes';
}
