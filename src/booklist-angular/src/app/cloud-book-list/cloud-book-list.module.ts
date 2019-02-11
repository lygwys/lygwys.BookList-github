import { BooktagNzselectComponent } from './components/booktag-nzselect/booktag-nzselect.component';
import { AbpModule, LocalizationService } from '@yoyo/abp';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CloudBookListRoutingModule } from './cloud-book-list-routing.module';
import { BookListsComponent } from './book-lists/book-lists.component';

import { SharedModule } from '@shared/shared.module';
import { TitleService } from 'yoyo-ng-module/src/theme';

import { BookComponent } from './Books/Client/NGZorro/books/book.component';
import { CreateOrEditBookComponent } from './Books/Client/NGZorro/books/create-or-edit-book/create-or-edit-book.component';
import { BookTagComponent } from './book-tags/book-tag.component';
import { CreateOrEditBookTagComponent } from './book-tags/create-or-edit-book-tag/create-or-edit-book-tag.component';
import { ImgShowComponent } from './components/img-show/img-show.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule, //
    SharedModule, //
    AbpModule, //
    CloudBookListRoutingModule,
  ],
  declarations: [
    BookListsComponent,
    BookComponent,
    ImgShowComponent,
    BooktagNzselectComponent,
    CreateOrEditBookComponent,
    BookTagComponent,
    CreateOrEditBookTagComponent,
  ], // 属于该模块的组件、指令和管道（可声明对象）
  entryComponents: [
    BookListsComponent,
    BookComponent,
    ImgShowComponent,
    BooktagNzselectComponent,
    CreateOrEditBookComponent,
    CreateOrEditBookTagComponent,
  ], // 实际使用到的组件，生产环境编译时用到
  providers: [LocalizationService, TitleService], // 多语言，标题服务,依赖注入实现的一个增强
})
export class CloudBookListModule {}
