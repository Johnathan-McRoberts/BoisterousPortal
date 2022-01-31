export class BookReadDetailDto {
  constructor(
    public id: number = 0,
    public title: string = "",
    public author: string = "",
    public dateRead: Date = new Date(),
    public pages: number = 0,
    public imageUrl: string = "",
    public user: string = "",
    public nationality: string = "",
    public format: string = "",
    public language: string = "",
    public tags: string[] = []) { }

}
