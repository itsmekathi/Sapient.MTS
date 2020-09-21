export class MedicineModel {
  constructor(
    id: number,
    fullName: string,
    brand: string,
    price: number,
    quantity: number,
    expiryDate: Date,
    notes: string
  ) {
    this.id = id;
    this.fullName = fullName;
    this.brand = brand;
    this.price = price;
    this.quantity = quantity;
    this.expiryDate = expiryDate;
    this.notes = notes;
  }
  id: number;
  fullName: string;
  brand: string;
  price: number;
  quantity: number;
  expiryDate: Date;
  notes: string;
}
