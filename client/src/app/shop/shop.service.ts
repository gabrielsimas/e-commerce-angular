import { IProductBrand } from './../shared/models/productBrand';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IProductType } from '../shared/models/productType';
import {delay, map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) {

  }

  getProducts(brandId?: number, typeId?:number) {
    let params = new HttpParams();

    if(brandId) {
      params = params.append('brandId', brandId.toString());
    }

    if(typeId) {
      params = params.append('typeId', typeId.toString());
    }

    return this.http.get<IPagination>(`${this.baseUrl}/products`, {observe: 'response', params})
      .pipe(
        delay(1000),
        map(response => {
          return response.body;
        })
      );
  }

  getBrands() {
    return this.http.get<IProductBrand[]>(`${this.baseUrl}/products/brands`);
  }

  getTypes() {
    return this.http.get<IProductType[]>(`${this.baseUrl}/products/types`);
  }
}
