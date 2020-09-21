import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './components/main-component/main.component';
import { MedicineDetailsComponent } from './components/medicine-details-component/medicine-details.component';
import { EditMedicineDetailsComponent } from './components/edit-medicine-details-component/edit-medicine-details.component';
import { CreateMedicineComponent } from './components/create-medicine-component/create-medicine.component';
import { PageNotFoundComponent } from './components/page-not-found-component/page-not-found.component';
import { MedicineDetailResolver } from './services/medicine-detail-resover';

const routes: Routes = [
  { path: '', redirectTo: 'medicines', pathMatch: 'full' },
  {
    path: 'medicines',
    children: [
      {
        path: '',
        component: MainComponent,
      },
      {
        path: 'new',
        component: CreateMedicineComponent,
      },
      {
        path: 'details/:id',
        component: MedicineDetailsComponent,
        resolve: {
          medicine: MedicineDetailResolver,
        },
      },
      {
        path: 'edit/:id',
        component: EditMedicineDetailsComponent,
        resolve: {
          medicine: MedicineDetailResolver,
        },
      },
    ],
  },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
