import {
  BookListDto,
  BookServiceProxy,
} from './../../../shared/service-proxies/service-proxies';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/component-base/paged-listing-component-base';
import { Component, OnInit, Inject, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { inject } from '@angular/core/testing';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { CreateOrEditBookComponent } from './create-or-edit-book/create-or-edit-book.component';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styles: ['./books.component.less'], // 手动创建样式文件，在当前文件夹中新建books.component.less样式文件
  // animations: [appModuleAnimation], // 动画
})
export class BooksComponent extends PagedListingComponentBase<BookListDto>
  implements OnInit {
  constructor(injector: Injector, private _bookservice: BookServiceProxy) {
    super(injector);
  }
  /**
   * 默认获取后端分页数据列表信息
   * @param request 请求数据的Dto，比如分页的有关
   * @param pageNumber 当前的页码
   * @param finishedCallback 完成请求后的回调信息
   */
  protected fetchDataList(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function,
  ): void {
    this._bookservice
      .getPagedBook(
        this.filterText, // 绑定的字段
        request.sorting,
        request.skipCount,
        request.maxResultCount,
      ) // 传入模糊查询的值
      .pipe(
        finalize(() => {
          finishedCallback();
        }),
      ) // angular定义的管道，请求过程中的处理，比如弹出框等
      .subscribe(result => {
        // 订阅结束的操作，是有生命周期的
        this.dataList = result.items;
        this.showPaging(result);
      });
  }

  delete(entity: BookListDto): void {
    this._bookservice.deleteBook(entity.id).subscribe(() => {
      this.refreshGoFirstPage();
      this.notify.success('信息删除成功');
    });
  }

  batchDelete(): void {
    const selectIdCount = this.selectedDataItems.length;
    if (selectIdCount <= 0) {
      abp.message.warn('请选择您要删除的数据信息');
      return;
    }
    abp.message.confirm('是否确认删除以下数据信息？', res => {
      if (res) {
        const ids = _.map(this.selectedDataItems, 'id');
        this._bookservice.batchDelete(ids).subscribe(() => {
          this.refreshGoFirstPage();
          abp.notify.success('信息删除成功！');
        });
      }
    });
  }

  // 添加&修改页面
  createOrEdit(id?: number): void {
    this.modalHelper // 模态框
      .static(CreateOrEditBookComponent, { id: id }) // 静态模态框，点击提示是否允许关闭，调用组件信息并传id参
      .subscribe(result => {
        // 执行后的结果返回前端
        if (result) {
          // 是否有值
          this.refresh(); // 刷新当前列表页面，不管添加还是删除
        }
      });
  }
}
