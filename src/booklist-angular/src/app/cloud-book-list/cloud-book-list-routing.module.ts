import { BooksComponent } from './books/books.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListsComponent } from './book-lists/book-lists.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'booklists',
        component: BookListsComponent,
      },
      {
        path: 'books',
        component: BooksComponent,
        data: { permission: 'Pages.BookManager' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CloudBookListRoutingModule {}
