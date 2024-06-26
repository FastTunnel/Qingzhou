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

import { mapValues } from '../runtime';
import type { Organization } from './Organization';
import {
    OrganizationFromJSON,
    OrganizationFromJSONTyped,
    OrganizationToJSON,
} from './Organization';

/**
 * 
 * @export
 * @interface LoginResponse
 */
export interface LoginResponse {
    /**
     * 
     * @type {string}
     * @memberof LoginResponse
     */
    token?: string;
    /**
     * 
     * @type {Array<Organization>}
     * @memberof LoginResponse
     */
    teams?: Array<Organization>;
}

/**
 * Check if a given object implements the LoginResponse interface.
 */
export function instanceOfLoginResponse(value: object): boolean {
    return true;
}

export function LoginResponseFromJSON(json: any): LoginResponse {
    return LoginResponseFromJSONTyped(json, false);
}

export function LoginResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): LoginResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'token': json['token'] == null ? undefined : json['token'],
        'teams': json['teams'] == null ? undefined : ((json['teams'] as Array<any>).map(OrganizationFromJSON)),
    };
}

export function LoginResponseToJSON(value?: LoginResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'token': value['token'],
        'teams': value['teams'] == null ? undefined : ((value['teams'] as Array<any>).map(OrganizationToJSON)),
    };
}

