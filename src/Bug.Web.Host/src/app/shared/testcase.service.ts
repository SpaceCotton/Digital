import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestcaseService {

  private testcases: Testcase[] = [
    new Testcase(1, '机器号：1', '效率：98.0%', '停锭数：4', open, 2018 / 12 / 23),
    new Testcase(2, '机器号：2', '效率：96.1 % ', '停锭数：6', open, 2018 / 12 / 23),
    new Testcase(3, '机器号：3', '效率：97 % ', '停锭数：7', open, 2018 / 12 / 23),
    new Testcase(4, '机器号：4', '效率：95.4 % ', '停锭数：5', open, 2018 / 12 / 23),
    new Testcase(5, '机器号：5', '效率：99.5 % ', '停锭数：3', open, 2018 / 12 / 23),
    new Testcase(6, '机器号：6', '效率：98.8 % ', '停锭数：2', open, 2018 / 12 / 23)
  ];


  private machineDataTokenShortCodeActGrpRot: MachineDataTokenShortCodeActGrpRot[] = [
    new MachineDataTokenShortCodeActGrpRot(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19),
    new MachineDataTokenShortCodeActGrpRot(2, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1),
    new MachineDataTokenShortCodeActGrpRot(3, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1),
    new MachineDataTokenShortCodeActGrpRot(4, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1),
    new MachineDataTokenShortCodeActGrpRot(5, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1),
    new MachineDataTokenShortCodeActGrpRot(6, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1),
  ];
  constructor() { }

  getTestcases() {
    return this.testcases;
  }

  getMachineDataTokenShortCodeActGrpRot() {
    return this.machineDataTokenShortCodeActGrpRot;
  }
}


export class Testcase {

  constructor (

    public AssignedPersonId: number, // 分配人ID
    public AssignedPerson: any, // 分配人
    public Title: any, // 主题
    public Description: any, // 描述
    public State: any, // 状态
    public CreationTime, // 创建时间

  ) {

  }
}


export class MachineDataTokenShortCodeActGrpRot {

  constructor (
    public MachineId: any, // 设备ID
    public PR: any, // 接头可靠性
    public Shift: any, // 班效率
    public fPos: any, // 起始锭位
    public Grp: any, // 生产组
    public GS: any, // 生产组状态
    public JobID: any, // 批号
    public JobKg: any, // 生产实际重量
    public PJobnDPR: any, // 生产实际汇总
    public lPos: any, // 结束锭位
    public nCCl: any, // 纱线检测 / 1000Rh
    public nYB: any, // 断纱 / 1000Rh
    public ProductID: any, // 生产批号
    public kg: any, // 产量
    public RecipeID: any, // 品种批号
    public SupplyID: any, // 供应批号
    public taRL: any, // 红灯处理平均时间
    public TJobKg: any, // 生产目标重量
    public TJobnDP: any, // 生产目标汇总
    public tJobRem: any, // 生产剩余时间
  ) {

  }
}
