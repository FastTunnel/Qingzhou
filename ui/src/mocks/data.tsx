import { DemandInfo } from "@/apis";
import { faker } from "@faker-js/faker";

export function myDemands(): DemandInfo[] {
    const list = [];
    for (let index = 0; index < 5; index++) {
        list.push({
            projectId: "7",
            demand_id: 11,
            demand_title: "需求1",
            content: "优化样式",
            demand_content: "# 优化样式",
            demand_status_name: "进行中",
            create_userid: faker.number.int(),
            create_name: faker.person.fullName(),
            create_time_str: "2024-1-20 22:22:22",
            status_id: 1,
            urgency_level: 1,
            urgency_level_name: "紧急",
            research_user_id: faker.number.int(),
            research_user_name: "韩bg",
        })
    }
    console.log(list);

    return list;
}