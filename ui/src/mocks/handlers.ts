import {
  LoginByUserName,
  CreateOrg,
  ProjectViews,
  GetProjects,
  GetProject,
  GetDemands,
  GetDemandDetail,
  GetTodDemands,
  GetProjectTemplates,
  CreateProject,
} from "@/apis";
import { myDemands } from "./data";
import { faker } from "@faker-js/faker";

export const handlers = [
  new LoginByUserName().mock({
    teams: [
      {
        name: "名字",
        teamId: "ddddd",
      },
    ],
    token:
      "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJieC11c2VyIjoie1wiVXNlck5hbWVcIjpcIlxcdTk3RTlcIixcIlVzZXJJZFwiOjExMDAwMzExfSIsImV4cCI6MTcwNDg5ODg5OSwiaXNzIjoiQlgiLCJhdWQiOiJodHRwczovL2J4LmNvbS5jbiJ9.X6NbJIFEK_bgaHlXFo5P4iUr4OA_-Ow06uU_6bO9D24",
  }),
  new CreateOrg().mock({
    Name: "11",
    teamId: "111",
  }),
  new ProjectViews().mock({
    views: [
      {
        name: "我参与的",
        filter: "joined",
        identifier: "joined",
      },
      {
        name: "我管理的",
        filter: "guanli",
        identifier: "guanli",
      },
      {
        name: "全部",
        filter: "all",
        identifier: "all",
      },
    ],
  }),
  new GetProjects().mock({
    rows: [
      {
        teamId: "ddd",
        productid: 11,
        productname: "项目名称",
        productcode: 111,
        status: 1,
        productinfo: "productinfo",
        syscreatetime: "2024-1-20 22:22:22",
      },
    ],
    count: 2,
  }),
  new GetProject().mock({
    teamId: "ddd",
    productid: 11,
    productname: "项目名称",
    productcode: 111,
    status: 1,
    productinfo: "productinfo",
    syscreatetime: "2024-1-20 22:22:22",
  }),
  new GetDemands().mock({
    rows: [
      {
        teamId: "ddd",
        demand_id: 11,
        projectId: "7",
        demand_title: "需求1",
        content: "优化样式",
        demand_content: "# 优化样式",
        demand_status_name: "进行中",
        create_userid: 111,
        create_name: "韩",
        create_time_str: "2024-1-20 22:22:22",
        status_id: 1,
        urgency_level: 1,
        urgency_level_name: "紧急",
        research_user_id: 1111,
        research_user_name: "韩bg",
      },
    ],
    count: 1,
  }),
  new GetDemandDetail().mock({
    teamId: "ddd",
    demand_id: 11,
    projectId: "7",
    demand_title: "需求1",
    content: "优化样式",
    demand_content: "# 优化样式",
    demand_status_name: "进行中",
    create_userid: 111,
    create_name: faker.person.fullName(),
    create_time_str: "2024-1-20 22:22:22",
    status_id: 1,
    urgency_level: 1,
    urgency_level_name: "紧急",
    research_user_id: 1111,
    research_user_name: "韩bg",
  }),
  new GetTodDemands().mock(myDemands()),
  new GetProjectTemplates().mock({
    templates: [
      {
        templateId: "templateId11",
        templateName: "敏捷研发管理",
        desc: "快速、有效的落地Scrum，合理规划并形成交付节奏，持续提升敏捷交付能力",
      },
      {
        templateId: "templateId22",
        templateName: "自定义模板",
        desc: "快速、有效的落地Scrum，合理规划并形成交付节奏，持续提升敏捷交付能力",
      },
    ],
  }),
  new CreateProject().mock({
    projectId: "11111",
  }),
];
