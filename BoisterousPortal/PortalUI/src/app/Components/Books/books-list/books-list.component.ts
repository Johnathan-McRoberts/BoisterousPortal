import { Component, OnInit, ViewChild, AfterViewInit} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';

import { Router } from '@angular/router';

import { Observable, of, BehaviorSubject, combineLatest, merge, Subject } from 'rxjs';

import { BooksDbService } from './../../../Services/books-db.service';

import { BookSummary, BooksReadSummaryDto } from './../../../Models/book-summary';


@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit, AfterViewInit {

  constructor(
    public router: Router,
    public booksDbService: BooksDbService) { }

  public bookSummaries$: Observable<BookSummary[]> | any = null;

  ngOnInit(): void {

    this.booksDbService.getBookSummaries()
      .subscribe((subscribed: BooksReadSummaryDto) => {

        this.bookSummaries$ = of(subscribed.summarySet);


        this.dataSource.data = subscribed.summarySet;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.sort.sortChange.subscribe(() => {
          this.paginator.pageIndex = 0;
          this.paginator._changePageSize(this.paginator.pageSize);
        });

      }, (err) => {

        console.log(err);
      });
  }


  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {


            case 'dateRead': return new Date( item.dateRead).getTime();
            case 'author': return item.author;
            case 'pages': return item.pages;
            case 'title': return item.title;
            default: return '';

      }
    };
  }


  displayedColumns: string[] = ['author', 'title', 'pages', 'dateRead'];

  dataSource = new MatTableDataSource<BookSummary>();
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator | any;
  @ViewChild(MatSort, { static: true }) sort: MatSort | any;


  onBooksRowClicked(row: BookSummary) {

    console.log('Books Row clicked: ', JSON.stringify(row, null, 4));


    //let url: string = "/books-list/" + row.id
    let url: string = "/book-detail/" + row.id;
    
    this.router.navigateByUrl(url);

  }

  applyBooksFilter(eventTarget: any) {
    let filterValue: string = (eventTarget as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.paginator.pageIndex = 0;
      this.paginator._changePageSize(this.paginator.pageSize);
    }
  }

}
