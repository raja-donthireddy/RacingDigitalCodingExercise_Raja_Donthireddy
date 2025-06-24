import { Routes } from '@angular/router';
import { RaceListComponent } from './features/races/race-list/race-list.component';

export const routes: Routes = [
  { path: '', redirectTo: 'races', pathMatch: 'full' },
  { path: 'races', component: RaceListComponent },
  {
  path: 'races/:id',
  loadComponent: () =>
    import('./features/races/race-detail/race-detail.component').then(m => m.RaceDetailComponent)
}
];