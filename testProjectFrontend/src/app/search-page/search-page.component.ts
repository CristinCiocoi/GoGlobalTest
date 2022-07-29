import { Component, OnInit } from '@angular/core';
import {
  IBookMark,
  IItem,
  RepositoryService,
} from '../services/repository.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookMarkService } from '../services/bookmark.service';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.sass'],
  providers: [RepositoryService, BookMarkService],
})
export class SearchPageComponent implements OnInit {
  public data: IBookMark;
  search: string = '';

  loginForm: FormGroup;

  constructor(
    private repository: RepositoryService,
    private _formGroupBuilder: FormBuilder,
    private bookMarkService: BookMarkService
  ) {}

  ngOnInit(): void {
    this.loginForm = this._formGroupBuilder.group({
      inputSearch: ['', [Validators.required]],
    });
  }

  public onSearch() {
    this.repository
      .SearchRepository(this.loginForm.controls['inputSearch'].value)
      .subscribe((res) => {
        this.data = res;
        console.log(res);
      });
  }

  public AddBookMark(model: IItem) {
    this.bookMarkService.AddBookMark(model).subscribe((res) => {
      alert('Ok');
    });
  }
}
