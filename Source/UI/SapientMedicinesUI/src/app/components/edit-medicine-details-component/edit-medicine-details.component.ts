import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MedicineModel } from 'src/app/models/medicine.model';
import { MedicineService } from 'src/app/services/medicine.service';
@Component({
  selector: 'app-edit-medicine-details',
  templateUrl: './edit-medicine-details.component.html',
  styleUrls: ['./edit-medicine-details.component.scss'],
})
export class EditMedicineDetailsComponent implements OnInit, OnDestroy {
  medicineDetail: MedicineModel;
  private sub: any;
  constructor(
    private route: ActivatedRoute,
    private medicineService: MedicineService
  ) {}
  ngOnInit(): void {
    this.medicineDetail = this.route.snapshot.data.medicine;
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
