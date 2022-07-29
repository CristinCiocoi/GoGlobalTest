import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { BookmarkPageComponent } from './bookmark-page/bookmark-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  {
    path: 'bookmark',
    component: BookmarkPageComponent,
    canActivate: [AuthGuard],
  },
  { path: 'search', component: SearchPageComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
