import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './components/main-component/main.component';
import { MedicineDetailsComponent } from './components/medicine-details-component/medicine-details.component';
import { PageNotFoundComponent } from './components/page-not-found-component/page-not-found.component';
import { MedicineDetailResolver } from './services/medicine-detail-resover';

const routes: Routes = [
  { path: '', redirectTo: 'medicines', pathMatch: 'full' },
  { path: 'medicines', component: MainComponent },
  {
    path: 'details/:id',
    component: MedicineDetailsComponent,
    resolve: {
      medicine: MedicineDetailResolver,
    },
  },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
