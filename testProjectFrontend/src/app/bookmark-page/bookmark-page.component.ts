import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BookMarkService } from '../services/bookmark.service';
import { IBookMark, IItem } from '../services/repository.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-bookmark-page',
  templateUrl: './bookmark-page.component.html',
  styleUrls: ['./bookmark-page.component.sass'],
  providers: [BookMarkService],
})
export class BookmarkPageComponent implements OnInit {
  data: IItem[];
  closeResult = '';
  constructor(
    private bookMarkService: BookMarkService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.bookMarkService.GetAllBookMarks().subscribe((res) => {
      this.data = res;
    });
  }

  public UnBookMark(id: string) {
    this.bookMarkService.DeleteBookMark(id).subscribe((res) => {
      window.location.reload();
    });
  }

  public ExportData() {
    this.bookMarkService.ExportData().subscribe((res: HttpResponse<Blob>) => {
      const url = window.URL.createObjectURL(res.body as unknown as Blob);
      let a = document.createElement('a');
      a.href = url;
      a.setAttribute('download', 'data.csv');
      a.click();
    });
  }

  public SendMsg(email: string) {
    this.bookMarkService.SendMessage(email).subscribe((res) => {
      window.location.reload();
    });
  }

  open(content: any) {
    this.modalService
      .open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then(
        (result) => {
          this.closeResult = `Closed with: ${result}`;
        },
        (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
