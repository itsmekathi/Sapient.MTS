import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { MedicineModel } from '../models/medicine.model';
import { Observable } from 'rxjs';

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
  public getById(id: number): Observable<MedicineModel> {
    return this.http
      .get<MedicineModel>(
        `${environment.baseApiUrl}/api/medicines/getById/${id}`
      );
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
  public async updateMedicine(
    medicineModel: MedicineModel
  ): Promise<MedicineModel> {
    return this.http
      .post<MedicineModel>(
        `${environment.baseApiUrl}/api/medicines/update/${medicineModel.id}`,
        medicineModel
      )
      .toPromise();
  }
}
