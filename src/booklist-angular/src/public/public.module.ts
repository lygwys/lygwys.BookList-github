import { BookListShareComponent } from './book-list-share/book-list-share.component';
import { AbpModule } from '@yoyo/abp';
import { JsonpModule, HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicComponent } from './public.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { SharedModule } from '@shared/shared.module';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { PublicRoutingModule } from './public-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    JsonpModule,
    NgZorroAntdModule,
    AbpModule,
    SharedModule,
    ServiceProxyModule,
    PublicRoutingModule,
  ],
  declarations: [BookListShareComponent, PublicComponent],
  entryComponents: [],
})
export class PublicModule {}
