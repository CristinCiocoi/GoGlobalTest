import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RepositoryService {
  constructor(private http: HttpClient) {}

  public SearchRepository(keyword: string) {
    return this.http.get<IBookMark>(
      `https://localhost:7261/api/Repository/search?keyword=${keyword}`
    );
  }
}

export interface IBookMark {
  items: IItem[];
}

export interface IItem {
  id: string;
  name: string;
  description: string;
  avatarUrl: string;
  owner: IImg;
}

export interface IImg {
  avatar_url: string;
}
