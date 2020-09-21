import { Component } from '@angular/core';
import { MedicineModel } from 'src/app/models/medicine.model';
import { MedicineService } from 'src/app/services/medicine.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import * as moment from 'moment';
@Component({
  selector: 'app-create-medicine',
  templateUrl: './create-medicine.component.html',
  styleUrls: ['./create-medicine.component.scss'],
})
export class CreateMedicineComponent {
  public medicineModel: MedicineModel;
  constructor(
    private medicineService: MedicineService,
    private router: Router
  ) {
    this.medicineModel = new MedicineModel(0, '', '', 0, 0, new Date(), '');
  }
  async createMedicine(medicineForm: NgForm): Promise<void> {
    if (medicineForm.valid) {
      const nowPlus30Days = moment(new Date());
      nowPlus30Days.add(30, 'days');
      if (moment(this.medicineModel.expiryDate).toDate() < nowPlus30Days.toDate()) {
        alert('Medicine with Expiry date less than 30 days will not be allowed to add in the stock.');
        return;
      }
      try {
        await this.medicineService.addMedicine(this.medicineModel);
        this.router.navigate(['/medicines']);
      } catch (err) {
        console.log('Error occured while saving the record');
      }
    }
  }
}
