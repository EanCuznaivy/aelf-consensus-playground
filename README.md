# What is AElf Consensus
todo

# How to customize AElf Consensus

You need to complete two tasks:

1. Develop a consensus contract implemented [acs4](https://aelf-boilerplate-docs.readthedocs.io/en/latest/acs/acs4.html).

2. Implement some interfaces related to consensus.

# Interfaces related to consensus

## IContractInitializationProvider

To set the new consensus contract as the AElf consensus contract by binding `ConsensusSmartContractAddressNameProvider.Name` to the new contract name.

## ITriggerInformationProvider

ITriggerInformationProvider is for generating some necessary information to trigger consensus hints from consensus contract.

## IBroadcastPrivilegedPubkeyListProvider

IBroadcastPrivilegedPubkeyListProvider is just a helper for network module to broadcast blocks to nodes of higher priority.

## IConsensusExtraDataExtractor

IConsensusExtraDataExtractor is for extracting consensus data from extra data in Block Header.

## ConsensusValidationFailedEventHandler[Optional]

An event handler to deal with the situation when the consensus validation of block failed.