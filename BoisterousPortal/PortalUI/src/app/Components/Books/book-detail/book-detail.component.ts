import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { BooksDbService } from './../../../Services/books-db.service';

import { BookReadDetailDto } from './../../../Models/book-read-detail-dto';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.scss']
})
export class BookDetailComponent implements OnInit {

  constructor(private router: Router,
    public booksDbService: BooksDbService) { }

  ngOnInit(): void {
    let bookId = this.getKey();



    this.booksDbService.getBookDetail(bookId)
      .subscribe((bookDetail: BookReadDetailDto) => {

        this.detail = JSON.stringify(bookDetail, null, 4);

        console.log(" book detail " + this.detail);

      }, (err) => {

        console.log(err);
      });
  }

  public detail: string | any = null;

  private getKey(): number {
    console.log(" BOOK detail is at " + this.router.url);

    let splitted: string[] = this.router.url.split("/");
    console.log(splitted)
    let last: string = splitted[splitted.length - 1];
    let key: number = +last;
    console.log(" BOOK detail key " + key);

    return key;

  }

}
