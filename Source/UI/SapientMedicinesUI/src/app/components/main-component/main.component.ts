import { Component, OnInit } from '@angular/core';
import { MedicineService } from 'src/app/services/medicine.service';
import { MedicineModel } from 'src/app/models/medicine.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {
  medicines: Array<MedicineModel> = [];
  constructor(private medicineService: MedicineService) {}
  async ngOnInit(): Promise<void> {
    this.medicines = await this.medicineService.getAllMedicines();
  }
  searchMedicines($event): void {
    console.log($event);
  }
}
