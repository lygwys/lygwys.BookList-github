import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './Books/Client/NGZorro/books/book.component';
import { BookTagComponent } from './book-tags/book-tag.component';
import { CloudBookListComponent } from './cloud-books-lists/cloud-book-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'book',
        component: BookComponent,
        data: { permission: 'Pages.Book' },
      },
      {
        path: 'book-tag',
        component: BookTagComponent,
        data: { permission: 'Pages.BookTag' },
      },
      {
        path: 'cloud-book-list',
        component: CloudBookListComponent,
        data: { permission: 'Pages.CloudBookList' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CloudBookListRoutingModule {}
