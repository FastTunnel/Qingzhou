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
  LoginCommand,
  LoginResponse,
} from '../models/index';
import {
    LoginCommandFromJSON,
    LoginCommandToJSON,
    LoginResponseFromJSON,
    LoginResponseToJSON,
} from '../models/index';

export interface GetTokenRequest {
    loginCommand?: LoginCommand;
}

/**
 * 
 */
export class UserApi extends runtime.BaseAPI {

    /**
     */
    async getTokenRaw(requestParameters: GetTokenRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<LoginResponse>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/User/GetToken`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: LoginCommandToJSON(requestParameters['loginCommand']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => LoginResponseFromJSON(jsonValue));
    }

    /**
     */
    async getToken(requestParameters: GetTokenRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<LoginResponse> {
        const response = await this.getTokenRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
