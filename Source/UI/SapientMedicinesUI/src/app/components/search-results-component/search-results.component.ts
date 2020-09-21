import { Component, Input } from '@angular/core';
import { MedicineModel } from '../../models/medicine.model';
import * as moment from 'moment';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss'],
})
export class SearchResultsComponent {
  @Input() medicines: Array<MedicineModel> = [];

  public isMedicineExpiringIn30Days(medicineModel: MedicineModel): boolean {
    const nowPlus30Days = moment(new Date());
    nowPlus30Days.add(30, 'days');
    if (moment(medicineModel.expiryDate).toDate() < nowPlus30Days.toDate()) {
      return true;
    }
    return false;
  }
}
