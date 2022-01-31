import { TestBed } from '@angular/core/testing';

import { BooksDbService } from './books-db.service';

describe('BooksDbService', () => {
  let service: BooksDbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BooksDbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
