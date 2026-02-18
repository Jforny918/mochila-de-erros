import { Routes } from '@angular/router';
import { MochilasPage } from './features/mochilas/pages/mochilas-page/mochilas-page/mochilas-page';
import { QuestoesPage } from './features/mochilas/pages/questoes-page/questoes-page';

export const routes: Routes = [
    { path: '', redirectTo: 'mochilas', pathMatch: 'full' },
    { path: 'mochilas', component: MochilasPage },
    { path: 'mochilas/:mochilaId/questoes', component: QuestoesPage }
];
