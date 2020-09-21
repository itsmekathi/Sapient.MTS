import { Injectable } from '@angular/core';
import { MedicineModel } from '../models/medicine.model';
import { MedicineService } from './medicine.service';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable()
export class MedicineDetailResolver implements Resolve<MedicineModel> {
  constructor(
    private medicineService: MedicineService,
    private router: Router
  ) {}
  resolve(route: ActivatedRouteSnapshot): Observable<MedicineModel> {
    const id = +route.params.id;
    return this.medicineService.getById(id);
  }
}
