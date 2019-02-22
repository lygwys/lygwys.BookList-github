import { LoginService } from './../login/login.service';
import {
  TenantRegistrationServiceProxy,
  CreateTenantDto,
} from './../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import { Component, OnInit, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-tenant-register',
  templateUrl: './tenant-register.component.html',
  styles: ['./tenant-register.component.less'],
  animations: [appModuleAnimation()],
})
export class TenantRegisterComponent extends AppComponentBase
  implements OnInit {
  model: CreateTenantDto = new CreateTenantDto();

  // tslint:disable-next-line:max-line-length
  constructor(
    injector: Injector,
    private _tenantService: TenantRegistrationServiceProxy,
    private _loginService: LoginService,
    private _router: Router,
  ) {
    super(injector);
  }

  ngOnInit() {}

  back(): void {
    this._router.navigate(['/account/login']);
  }

  save(): void {
    this.saving = false;
    this._tenantService
      .registerTenantAsync(this.model)
      .pipe(
        finalize(() => {
          this.saving = false;
        }),
      )
      .subscribe(result => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.saving = true;
        abp.multiTenancy.setTenantIdCookie(result.id);

        this._loginService.authenticateModel.userNameOrEmailAddress = this.model.adminEmailAddress;
        this._loginService.authenticateModel.password = this.model.passWord;
        this._loginService.authenticate(() => {
          this.saving = false;
        });
      });
  }
}
