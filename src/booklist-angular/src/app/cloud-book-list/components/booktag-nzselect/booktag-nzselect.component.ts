import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  ViewChild,
  Output,
  EventEmitter,
  Injector,
  Input,
} from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd';

@Component({
  selector: 'app-booktag-nzselect',
  templateUrl: './booktag-nzselect.component.html',
  styles: [],
})
export class BooktagNzselectComponent extends AppComponentBase
  implements OnInit {
  @ViewChild('booktagselect') booktagselect: NzSelectComponent;

  @Output()
  selectedDataChange = new EventEmitter();

  @Input()
  set tagsSourceData(value: any) {
    // 绑定了父组件的属性<app-booktag-nzselect name="tag" [tagsSourceData]="tags"，其实是将父的tags传给了子的value
    this.isLoading = true;
    if (value) {
      this.listOfTagOptions = value;
      this.listOfSelectedValue = [];
      this.listOfTagOptions.forEach(item => {
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
  isLoading = true;
  listOfTagOptions = [];
  listOfSelectedValue = [];

  constructor(injector: Injector) {
    super(injector);
  }

  handleInputConfim(): void {}
  modelChange(): void {
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
  }
  ngOnInit(): void {}
}
