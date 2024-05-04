/* tslint:disable */
/* eslint-disable */
/**
 * 轻舟 RestAPI
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
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

/**
 * 
 * @export
 * @interface QzResponseOfString
 */
export interface QzResponseOfString {
    /**
     * 
     * @type {boolean}
     * @memberof QzResponseOfString
     */
    success?: boolean;
    /**
     * 
     * @type {ErrorCode}
     * @memberof QzResponseOfString
     */
    code?: ErrorCode;
    /**
     * 
     * @type {string}
     * @memberof QzResponseOfString
     */
    data?: string;
    /**
     * 
     * @type {string}
     * @memberof QzResponseOfString
     */
    message?: string;
    /**
     * 
     * @type {string}
     * @memberof QzResponseOfString
     */
    traceId?: string;
}

/**
 * Check if a given object implements the QzResponseOfString interface.
 */
export function instanceOfQzResponseOfString(value: object): boolean {
    return true;
}

export function QzResponseOfStringFromJSON(json: any): QzResponseOfString {
    return QzResponseOfStringFromJSONTyped(json, false);
}

export function QzResponseOfStringFromJSONTyped(json: any, ignoreDiscriminator: boolean): QzResponseOfString {
    if (json == null) {
        return json;
    }
    return {
        
        'success': json['success'] == null ? undefined : json['success'],
        'code': json['code'] == null ? undefined : ErrorCodeFromJSON(json['code']),
        'data': json['data'] == null ? undefined : json['data'],
        'message': json['message'] == null ? undefined : json['message'],
        'traceId': json['traceId'] == null ? undefined : json['traceId'],
    };
}

export function QzResponseOfStringToJSON(value?: QzResponseOfString | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'success': value['success'],
        'code': ErrorCodeToJSON(value['code']),
        'data': value['data'],
        'message': value['message'],
        'traceId': value['traceId'],
    };
}
