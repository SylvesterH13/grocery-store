import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from 'src/models/product';
import { ProductService } from 'src/services/product-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  title = 'grocery-store-client';
  products: Array<Product>;

  name: string = '';
  description: string = '';
  category: string = '';
  rating?: number;
  price?: number;
  orderType: string = '';
  orderProperty: string = '';

  constructor(private productService: ProductService) {
    this.products = new Array<Product>();
  }
  
  ngOnInit(): void {
    this.productService.get()
      .subscribe((data: Array<Product>) => this.products = data);
  }

  clearFilter(): void {
    this.productService.get()
      .subscribe((data: Array<Product>) => this.products = data)

    this.name = '';
    this.description = '';
    this.category = '';
    this.rating = undefined;
    this.price = undefined;
  }

  getProducts(): void {
    this.productService.get(this.name, this.description, this.category, this.rating, this.price, this.orderType, this.orderProperty)
      .subscribe((data: Array<Product>) => this.products = data);
  }
}
