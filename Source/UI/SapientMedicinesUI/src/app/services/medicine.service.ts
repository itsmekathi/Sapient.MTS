import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { MedicineModel } from '../models/medicine.model';

@Injectable({ providedIn: 'root' })
export class MedicineService {
  constructor(private http: HttpClient) {}
  public async getAllMedicines(): Promise<Array<MedicineModel>> {
    return this.http
      .get<Array<MedicineModel>>(
        `${environment.baseApiUrl}/api/medicines/getall`
      )
      .toPromise();
  }
  public async addMedicine(
    medicineModel: MedicineModel
  ): Promise<MedicineModel> {
    return this.http
      .post<MedicineModel>(
        `${environment.baseApiUrl}/api/medicines/AddMedicine`,
        medicineModel
      )
      .toPromise();
  }
}
