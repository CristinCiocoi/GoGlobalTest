import { Injectable } from "@angular/core";
import { HttpClient, HttpResponse } from "@angular/common/http";
import { IBookMark, IItem } from "../services/repository.service";
import { Observable } from "rxjs";

@Injectable()
export class BookMarkService {
  constructor(private http: HttpClient) {}

  public AddBookMark(model: IItem) {
    return this.http.post("https://localhost:7261/api/BookMark", {
      NameRepository: model.name,
      description: model.description,
      avatarUrl: model.owner.avatar_url,
    });
  }

  public DeleteBookMark(id: string) {
    return this.http.delete(`https://localhost:7261/api/BookMark/${id}`);
  }

  public GetAllBookMarks() {
    return this.http.get<IItem[]>("https://localhost:7261/api/BookMark");
  }

  public ExportData(): Observable<HttpResponse<Blob>> {
    return this.http.get("https://localhost:7261/api/BookMark/export", {
      responseType: "blob",
      observe: "response",
    });
  }

  public SendMessage(email: string) {
    return this.http.post("https://localhost:7261/api/BookMark/send-msg", {
      email: email,
    });
  }
}
