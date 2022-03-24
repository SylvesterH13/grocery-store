import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Product } from 'src/model/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'grocery-store-client';
  products: Array<Product>;

  constructor(private http: HttpClient) {
    this.products = new Array<Product>();
  }

  getProducts(){
    return this.http.get<Array<Product>>('https://localhost:7146/api/Product')
      .subscribe((data: Array<Product>) => this.products = data);
  }

}
