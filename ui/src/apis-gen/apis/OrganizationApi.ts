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
  CreateOrganizationRequest,
  CreateOrganizationResponse,
  ListOrgResponse,
} from '../models/index';
import {
    CreateOrganizationRequestFromJSON,
    CreateOrganizationRequestToJSON,
    CreateOrganizationResponseFromJSON,
    CreateOrganizationResponseToJSON,
    ListOrgResponseFromJSON,
    ListOrgResponseToJSON,
} from '../models/index';

export interface CreateOrganizationOperationRequest {
    createOrganizationRequest?: CreateOrganizationRequest;
}

export interface DeleteOrganizationRequest {
    id?: string;
}

/**
 * 
 */
export class OrganizationApi extends runtime.BaseAPI {

    /**
     */
    async createOrganizationRaw(requestParameters: CreateOrganizationOperationRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<CreateOrganizationResponse>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Organization/CreateOrganization`,
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: CreateOrganizationRequestToJSON(requestParameters['createOrganizationRequest']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => CreateOrganizationResponseFromJSON(jsonValue));
    }

    /**
     */
    async createOrganization(requestParameters: CreateOrganizationOperationRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<CreateOrganizationResponse> {
        const response = await this.createOrganizationRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async deleteOrganizationRaw(requestParameters: DeleteOrganizationRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        if (requestParameters['id'] != null) {
            queryParameters['Id'] = requestParameters['id'];
        }

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Organization/DeleteOrganization`,
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async deleteOrganization(requestParameters: DeleteOrganizationRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.deleteOrganizationRaw(requestParameters, initOverrides);
    }

    /**
     */
    async listOrganizationsRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ListOrgResponse>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Organization/ListOrganizations`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ListOrgResponseFromJSON(jsonValue));
    }

    /**
     */
    async listOrganizations(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ListOrgResponse> {
        const response = await this.listOrganizationsRaw(initOverrides);
        return await response.value();
    }

}
