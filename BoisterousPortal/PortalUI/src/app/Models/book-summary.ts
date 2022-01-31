export class BookSummary {

  constructor(public id: number = 0,
    public title: string ="",
    public author: string ="",
    public dateRead: Date = new Date(),
    public pages: number = 0) {}
}

export class BooksReadSummaryDto {

  constructor(public summarySet: BookSummary[] = []) {}
}
