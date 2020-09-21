import { Component, Input } from '@angular/core';
import { MedicineModel } from '../../models/medicine.model';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss'],
})
export class SearchResultsComponent {
  @Input() medicines: Array<MedicineModel>;
}
