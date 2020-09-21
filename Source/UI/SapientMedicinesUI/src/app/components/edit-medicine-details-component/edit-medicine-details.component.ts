import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MedicineModel } from 'src/app/models/medicine.model';
import { MedicineService } from 'src/app/services/medicine.service';
@Component({
  selector: 'app-edit-medicine-details',
  templateUrl: './edit-medicine-details.component.html',
  styleUrls: ['./edit-medicine-details.component.scss'],
})
export class EditMedicineDetailsComponent implements OnInit {
  medicineModel: MedicineModel;
  private sub: any;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private medicineService: MedicineService
  ) {}
  ngOnInit(): void {
    this.medicineModel = this.route.snapshot.data.medicine;
  }
  async editMedicine(medicineForm): Promise<void> {
    try {
      await this.medicineService.updateMedicine(this.medicineModel);
      this.router.navigateByUrl('/medicines');
    } catch (err) {
      console.log('Error occured while saving the record');
    }
  }
}
