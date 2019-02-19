import { NzSelectComponent } from 'ng-zorro-antd';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  Inject,
  Injector,
  ViewChild,
  EventEmitter,
  Output,
  Input,
} from '@angular/core';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-book-nzselect',
  templateUrl: './book-nzselect.component.html',
  styles: [],
})
export class BookNzselectComponent extends AppComponentBase implements OnInit {
  constructor(injector: Injector) {
    super(injector);
  }

  @ViewChild('select') select: NzSelectComponent;
  @Output()
  selectedDataChange = new EventEmitter();

  isLoading = true;
  listOfOption = [];
  listOfSelectedValue = [];

  @Input()
  set bookSourceData(values: any) {
    this.isLoading = true;
    if (values) {
      this.listOfOption = values;
      this.listOfSelectedValue = [];
      this.listOfOption.forEach(item => {
        if (item.isSelected) {
          this.listOfSelectedValue.push(item.id);
        }
      });
    }
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
    this.isLoading = false;
  }

  ngOnInit() {}

  modelChange(): void {
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
  }
}
