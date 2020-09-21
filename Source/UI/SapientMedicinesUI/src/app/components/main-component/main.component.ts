import { Component, OnInit } from '@angular/core';
import { MedicineService } from 'src/app/services/medicine.service';
import { MedicineModel } from 'src/app/models/medicine.model';
import { cloneDeep, filter } from 'lodash';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {
  medicines: Array<MedicineModel> = [];
  filteredMedicines: Array<MedicineModel> = [];

  constructor(private medicineService: MedicineService) {}
  async ngOnInit(): Promise<void> {
    this.medicines = await this.medicineService.getAllMedicines();
    this.filteredMedicines = cloneDeep(this.medicines);
  }
  searchMedicines($event: string): void {
    this.filteredMedicines = cloneDeep(
      this.medicines.filter(
        (m) => m.fullName.toLowerCase().indexOf($event.toLowerCase()) !== -1
      )
    );
  }
}
