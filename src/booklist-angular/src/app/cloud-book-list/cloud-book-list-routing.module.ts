import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListsComponent } from './book-lists/book-lists.component';
import { BookComponent } from './Books/Client/NGZorro/books/book.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'booklists',
        component: BookListsComponent,
      },
      {
        path: 'book',
        component: BookComponent,
        data: { permission: 'Pages.Book' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CloudBookListRoutingModule {}
