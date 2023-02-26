import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../shared/models/brand';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/products';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getProducts(){
    return this.http.get<Pagination<Product[]>>( this.baseUrl + 'Products?pageSize=50');
  }
  
  getBrands(){
    return this.http.get<Brand[]>( this.baseUrl + 'Products/brands');
  }

  getTypes(){
    return this.http.get<Type[]>( this.baseUrl + 'Products/types');
  }
  
}
