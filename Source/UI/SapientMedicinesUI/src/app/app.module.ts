import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header-component/header.component';
import { FooterComponent } from './components/footer-component/footer.component';
import { MainComponent } from './components/main-component/main.component';
import { AddMedicineComponent } from './components/add-medicine-component/add-medicine.component';
import { MedicineDetailsComponent } from './components/medicine-details-component/medicine-details.component';
import { PageNotFoundComponent } from './components/page-not-found-component/page-not-found.component';
import { SearchComponent } from './components/search-component/search.component';
import { SearchResultsComponent } from './components/search-results-component/search-results.component';
import { MedicineService } from './services/medicine.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent,
    AddMedicineComponent,
    MedicineDetailsComponent,
    PageNotFoundComponent,
    SearchComponent,
    SearchResultsComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [MedicineService],
  bootstrap: [AppComponent],
})
export class AppModule {}
