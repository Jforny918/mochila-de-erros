import { Routes } from '@angular/router';
import { MochilasPage } from './features/mochilas/pages/mochilas-page/mochilas-page/mochilas-page';

export const routes: Routes = [
    { path: '', redirectTo: 'mochilas', pathMatch: 'full' },
    { path: 'mochilas', component: MochilasPage}
];
