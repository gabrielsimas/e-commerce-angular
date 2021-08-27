import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get500Error() {
    this.http.get(`${this.baseUrl}/buggy/servererror`).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    })
  }

  get400Error() {
    this.http.get(`${this.baseUrl}/buggy/badrequest`).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    })
  }

  get400ValidationError() {
    this.http.get(`${this.baseUrl}/products/fortytwo`).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
      this.validationErrors = error.errors;
    })
  }

  get404Error() {
    this.http.get(`${this.baseUrl}/products/42`).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    })
  }



}
