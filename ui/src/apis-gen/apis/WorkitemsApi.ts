/* tslint:disable */
/* eslint-disable */
/**
 * Qz.WebApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  MyIssueResponse,
} from '../models/index';
import {
    MyIssueResponseFromJSON,
    MyIssueResponseToJSON,
} from '../models/index';

export interface MyIssueRequest {
    organizationId: string;
}

/**
 * 
 */
export class WorkitemsApi extends runtime.BaseAPI {

    /**
     */
    async myIssueRaw(requestParameters: MyIssueRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<MyIssueResponse>> {
        if (requestParameters['organizationId'] == null) {
            throw new runtime.RequiredError(
                'organizationId',
                'Required parameter "organizationId" was null or undefined when calling myIssue().'
            );
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Organization/{organizationId}/Workitems/MyIssue`.replace(`{${"organizationId"}}`, encodeURIComponent(String(requestParameters['organizationId']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => MyIssueResponseFromJSON(jsonValue));
    }

    /**
     */
    async myIssue(requestParameters: MyIssueRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<MyIssueResponse> {
        const response = await this.myIssueRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
