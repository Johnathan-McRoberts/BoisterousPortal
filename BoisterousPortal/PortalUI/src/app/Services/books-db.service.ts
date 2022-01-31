import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';

import { Subject, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { environment } from './../../environments/environment';

import { BooksReadSummaryDto } from './../Models/book-summary';
import { BookReadDetailDto } from './../Models/book-read-detail-dto';

@Injectable({
  providedIn: 'root'
})
export class BooksDbService {

  constructor(private http: HttpClient) { }

  getBookSummaries(): Observable<BooksReadSummaryDto> {
    const url = `${environment.portalApiBase}/BooksDb/book-summaries`;
    return this.http.get<BooksReadSummaryDto>(url);
  }

  getBookDetail(bookId: number): Observable<BookReadDetailDto> {
    const url = `${environment.portalApiBase}/BooksDb/book/${bookId}`;
    return this.http.get<BookReadDetailDto>(url);
  }

}
