import { Component, Injector, ViewChild, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { UserServiceProxy, UserDto, PagedResultDtoOfUserDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { CreateUserComponent } from 'app/users/create-user/create-user.component';
import { EditUserComponent } from 'app/users/edit-user/edit-user.component';
import { finalize } from 'rxjs/operators';
import { MachineDataTokenShortCodeActGrpRot, MachineDataTokenShortCodeActGrpRotService} from '@app/shared/machine.service';

@Component({
    templateUrl: './machine.component.html',
    animations: [appModuleAnimation()]
})
export class MachineDataTokenShortCodeActGrpRotComponent  implements OnInit {

    private machineDataTokenShortCodeActGrpRot: MachineDataTokenShortCodeActGrpRot[] = [];

    // MachineDataTokenShortCodeActGrpRotService注入器
    constructor(private machineDataTokenShortCodeActGrpRotService: MachineDataTokenShortCodeActGrpRotService) {}

    ngOnInit() {

        // 依赖注入和传统的定义对象类和对new一个对象并属性赋值 的比较
         this.machineDataTokenShortCodeActGrpRot = this.machineDataTokenShortCodeActGrpRotService.getMachineDataTokenShortCodeActGrpRot();

    }


}
