import { IBasket } from './../shared/models/basket';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get(`${this.baseUrl}basket?id=${id}`)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
        })
      )
  }

  setBasket(basket: IBasket) {
    return this.http.post(`${this.baseUrl}basket`,basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
    }, error => {
      console.error(error);
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }
}
