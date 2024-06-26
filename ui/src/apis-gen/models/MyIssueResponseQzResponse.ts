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
import type { ErrorCode } from './ErrorCode';
import {
    ErrorCodeFromJSON,
    ErrorCodeFromJSONTyped,
    ErrorCodeToJSON,
} from './ErrorCode';
import type { MyIssueResponse } from './MyIssueResponse';
import {
    MyIssueResponseFromJSON,
    MyIssueResponseFromJSONTyped,
    MyIssueResponseToJSON,
} from './MyIssueResponse';

/**
 * 
 * @export
 * @interface MyIssueResponseQzResponse
 */
export interface MyIssueResponseQzResponse {
    /**
     * 
     * @type {boolean}
     * @memberof MyIssueResponseQzResponse
     */
    success?: boolean;
    /**
     * 
     * @type {ErrorCode}
     * @memberof MyIssueResponseQzResponse
     */
    code?: ErrorCode;
    /**
     * 
     * @type {MyIssueResponse}
     * @memberof MyIssueResponseQzResponse
     */
    data?: MyIssueResponse;
    /**
     * 
     * @type {string}
     * @memberof MyIssueResponseQzResponse
     */
    message?: string;
    /**
     * 
     * @type {string}
     * @memberof MyIssueResponseQzResponse
     */
    traceId?: string;
}

/**
 * Check if a given object implements the MyIssueResponseQzResponse interface.
 */
export function instanceOfMyIssueResponseQzResponse(value: object): boolean {
    return true;
}

export function MyIssueResponseQzResponseFromJSON(json: any): MyIssueResponseQzResponse {
    return MyIssueResponseQzResponseFromJSONTyped(json, false);
}

export function MyIssueResponseQzResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): MyIssueResponseQzResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'success': json['success'] == null ? undefined : json['success'],
        'code': json['code'] == null ? undefined : ErrorCodeFromJSON(json['code']),
        'data': json['data'] == null ? undefined : MyIssueResponseFromJSON(json['data']),
        'message': json['message'] == null ? undefined : json['message'],
        'traceId': json['traceId'] == null ? undefined : json['traceId'],
    };
}

export function MyIssueResponseQzResponseToJSON(value?: MyIssueResponseQzResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'success': value['success'],
        'code': ErrorCodeToJSON(value['code']),
        'data': MyIssueResponseToJSON(value['data']),
        'message': value['message'],
        'traceId': value['traceId'],
    };
}

